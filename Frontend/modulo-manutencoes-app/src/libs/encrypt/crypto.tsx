import { AES } from "crypto-ts";
import { WordArray } from "crypto-ts/src/lib/WordArray";
import { enc } from "crypto-ts";
import getEnv from "../../utils/generic/getEnv";

const secretKey: string = getEnv("SECRET_KEY");

export function encrypt(data: string | WordArray): string {
  const encryptData = AES.encrypt(data, secretKey).toString();

  return encryptData;
}

export function decrypt<T>(data: string | null): T | null {
  if (data === null) return null;

  const bytes: WordArray = AES.decrypt(data!, secretKey);

  const decryptedData: T = JSON.parse(bytes.toString(enc.Utf8));

  return decryptedData;
}
