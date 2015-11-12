/*
  Copyright 2015 Google Inc. All Rights Reserved.

  Licensed under the Apache License, Version 2.0 (the "License");
  you may not use this file except in compliance with the License.
  You may obtain a copy of the License at

  http://www.apache.org/licenses/LICENSE-2.0

  Unless required by applicable law or agreed to in writing, software
  distributed under the License is distributed on an "AS IS" BASIS,
  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
  See the License for the specific language governing permissions and
  limitations under the License.
*/

using System.IO.MemoryMappedFiles;
using System.Linq;

namespace ORFConverter {
  public class Converter {
    private struct TextTag {
      public TextTag(byte[] b) { bytes = b; length = b.Count(); }
      public byte[] bytes;
      public int length;
    }
    private static readonly TextTag[] kTags = {
      // "\0OLYMPUS IMAGING CORP.  \0"
      new TextTag(new byte[]
          { 0x00, 0x4F, 0x4C, 0x59, 0x4D, 0x50, 0x55, 0x53, 0x20, 0x49,
            0x4D, 0x41, 0x47, 0x49, 0x4E, 0x47, 0x20, 0x43, 0x4F, 0x52,
            0x50, 0x2E, 0x20, 0x20, 0x00 }),
      // "\0E-M10           \0"
      new TextTag(new byte[]
          { 0x00, 0x45, 0x2D, 0x4D, 0x31, 0x30, 0x20, 0x20, 0x20, 0x20,
            0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x00 }),
      // "\0OLYMPUS CORPORATION    \0"
      new TextTag(new byte[]
          { 0x00, 0x4F, 0x4C, 0x59, 0x4D, 0x50, 0x55, 0x53, 0x20, 0x43,
            0x4F, 0x52, 0x50, 0x4F, 0x52, 0x41, 0x54, 0x49, 0x4F, 0x4E,
            0x20, 0x20, 0x20, 0x20, 0x00 }),
      // "\0E-M10MarkII     \0"
      new TextTag(new byte[]
          { 0x00, 0x45, 0x2D, 0x4D, 0x31, 0x30, 0x4D, 0x61, 0x72, 0x6B,
            0x49, 0x49, 0x20, 0x20, 0x20, 0x20, 0x20, 0x00 }),
    };
    private const int kNumTags = 4;
    private const int kManufacturer = 0;
    private const int kCameraModel = 1;

    public static ConversionResult ConvertORF(
        string filePath, ConversionTarget conversion) {
      try {
        using (var mmf =
            MemoryMappedFile.CreateFromFile(
                filePath, System.IO.FileMode.Open)) {
          using (var mvs =
              mmf.CreateViewStream(0L, 0L, MemoryMappedFileAccess.ReadWrite)) {
            int[] foundCategory = new int[2] { -1, -1 };
            int[] matched = new int[kNumTags];
            // Read stream one byte at a time; memory-mapped so should be fast.
            for (int i; (i = mvs.ReadByte()) >= 0;) {
              byte b = (byte)i;
              // Search for all tags in the stream
              for (int t = 0; t < kNumTags; t++) {
                // If not already found, try to match next byte in t'th tag.
                if (matched[t] >= 0) {
                  if (kTags[t].bytes[matched[t]] == b) {
                    // Check if all bytes in the tag have been matched.
                    if (++matched[t] == kTags[t].length) {
                      int category = t & 1;
                      if (foundCategory[category] >= 0) {
                        // If we already have a tag for this category,
                        // something strange is going on. Bail.
                        return ConversionResult.FileStructureError;
                      }
                      // Record the position of the found tag.
                      foundCategory[category] =
                          (int)mvs.Position - kTags[t].length;
                      // Mark this tag as found.
                      matched[t] = -1;
                      // 
                      if (foundCategory[0] >= 0 && foundCategory[1] >= 0) {
                        int mfgIndex = 2 * (int)conversion + kManufacturer;
                        int cameraIndex = 2 * (int)conversion + kCameraModel;
                        // Write manufacturer tag.
                        mvs.Position = foundCategory[0];
                        mvs.Write(kTags[mfgIndex].bytes, 0,
                            kTags[mfgIndex].length);
                        // Write camera tag.
                        mvs.Position = foundCategory[1];
                        mvs.Write(kTags[cameraIndex].bytes, 0,
                            kTags[cameraIndex].length);
                        // Success!
                        return ConversionResult.Success;
                      }
                    }
                  } else if (matched[t] != 0) {
                    matched[t] = (kTags[t].bytes[0] == b) ? 1 : 0;
                  }
                }
              }
            }
          }
        }
        return ConversionResult.TagsNotFound;
      } catch {
        return ConversionResult.CaughtException;
      }
    }

    public enum ConversionTarget {
      EM10 = 0,
      EM10MarkII = 1
    }

    // Possible conversion results.
    public enum ConversionResult {
      Success = 0,
      CaughtException,
      TagsNotFound,
      FileStructureError,
    }
  }
}

