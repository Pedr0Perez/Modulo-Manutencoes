import { encryptData } from "../../libs/encrypt";

export default function setItemLocalStorage(
  key: string,
  value: any,
  criptografar: boolean = true
): void {
  if (criptografar) {
    localStorage.setItem(key, encryptData(value));
  }

  localStorage.setItem(key, value);
}
