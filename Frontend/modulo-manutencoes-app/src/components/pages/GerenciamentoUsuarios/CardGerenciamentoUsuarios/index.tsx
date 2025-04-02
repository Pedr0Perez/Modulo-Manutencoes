import { memo } from "react";
import DefaultCard from "../../../layout/DefaultCard";
import { JSX } from "@emotion/react/jsx-runtime";
import TabelaUsuarios from "./session/TabelaUsuarios";

const CardGerenciamentoUsuarios = (): JSX.Element => {
  return <DefaultCard titulo="Gerenciamento de Usuários">
    <TabelaUsuarios></TabelaUsuarios>
  </DefaultCard>;
};

export default memo(CardGerenciamentoUsuarios);
