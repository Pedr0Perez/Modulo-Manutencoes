import { WordArray } from "crypto-ts/src/lib/WordArray";
import secretKey from "./private/secretKey";
import { AES, enc } from "crypto-ts";

export const encryptData = (data: any): string => {
  return AES.encrypt(data, secretKey).toString();
};

export const decryptData = (encryptedData: string): string => {
  const bytes: WordArray = AES.decrypt(encryptedData, secretKey);

  return bytes.toString(enc.Utf8);
};
