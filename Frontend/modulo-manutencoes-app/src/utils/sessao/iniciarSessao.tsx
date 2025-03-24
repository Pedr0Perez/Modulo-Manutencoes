import { ILoginSucessoResposta } from "../../pages/Login/interface/ILoginSucessoResposta";
import setItemLocalStorage from "../localStorage/setItemLocalStorage";
import { encrypt } from "../../libs/encrypt/crypto";
import { IDataSession } from "./interface/IDataSession";
import toStringify from "../generic/toStringify";

export default function iniciarSessao(data: ILoginSucessoResposta): void {
  const dataSession: IDataSession = {
    email: data.email,
    nome: data.nome,
    genero: data.genero,
    expiracaoToken: data.expiracaoToken,
    auth: true,
  };

  setItemLocalStorage("data-session", encrypt(toStringify(dataSession)));
  setItemLocalStorage("token", data.token);
}
