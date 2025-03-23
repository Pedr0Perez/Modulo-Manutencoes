export default function getItemLocalStorage(key: string): string | null {
  return localStorage.getItem(key) ?? null;
}
