export default function GetEnv(key: string): string {
  //Função para coletar alguma configuração de ambiente no arquivo .env
  return import.meta.env[`VITE_${key}`];
}
