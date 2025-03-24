export default function toStringify<T>(data: T): string {
  if (data === null || data === undefined) return "";

  return JSON.stringify(data);
}
