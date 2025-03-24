import getItemLocalStorage from "../utils/localStorage/getItemLocalStorage";
import { IDataSession } from "../utils/sessao/interface/IDataSession";
import toJson from "../utils/generic/toJson";
import { decrypt } from "../libs/encrypt/crypto";

export default function verificarSessaoAtiva(): boolean {
  return (
    verificarSessaoAtivaNoLocalStorage() &&
    verificarSeTokenAindaEstaValidoPelaDataDeExpiracao()
  );
}

function verificarSessaoAtivaNoLocalStorage(): boolean {
  const dadosSessao: IDataSession | null = decrypt<IDataSession>(
    getItemLocalStorage("data-session")!
  );

  if (dadosSessao === null) return false;

  return dadosSessao!.auth;
}

function verificarSeTokenAindaEstaValidoPelaDataDeExpiracao(): boolean {
  const dadosSessao: IDataSession | null = decrypt<IDataSession>(
    getItemLocalStorage("data-session")!
  );

  return new Date() <= new Date(dadosSessao!.expiracaoToken);
}
