export default function getEnv(nameEnv: string): string {
  return import.meta.env[`VITE_API_${nameEnv}`];
}
