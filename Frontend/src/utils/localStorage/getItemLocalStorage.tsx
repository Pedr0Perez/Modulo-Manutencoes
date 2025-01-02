import { decryptData } from "../../libs/encrypt";

export default function getItemLocalStorage(
  value: string,
  estaCriptografado: boolean = true
): string {
  if (!localStorage.getItem(value)) return "";

  if (estaCriptografado) {
    return decryptData(localStorage.getItem(value)!);
  }

  return localStorage.getItem(value)!;
}
