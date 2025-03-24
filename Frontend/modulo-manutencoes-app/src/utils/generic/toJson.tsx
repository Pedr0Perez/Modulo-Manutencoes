export default function toJson<T>(data: string | null): T | null {
  if (data === null) return null;

  const item: T = JSON.parse(data!);

  return item;
}
