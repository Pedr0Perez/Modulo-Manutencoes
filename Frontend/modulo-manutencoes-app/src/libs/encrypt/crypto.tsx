import { AES } from "crypto-ts";
import { WordArray } from "crypto-ts/src/lib/WordArray";
import { enc } from "crypto-ts";
import getEnv from "../../utils/getEnv";

const secretKey: string = getEnv("SECRET_KEY");

export const encrypt = (data: any): string => {
  const encryptData = AES.encrypt(data, secretKey).toString();

  return encryptData;
};

export const decrypt = (data: string): any => {
  const bytes: WordArray = AES.decrypt(data, secretKey);

  const decryptedData = JSON.parse(bytes.toString(enc.Utf8));

  return decryptedData;
};
