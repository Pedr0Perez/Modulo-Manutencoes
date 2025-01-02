import { useEffect } from "react";
import alterarTitlePagina from "../utils/generic/alterarTitlePagina";
import UsuariosCard from "../components/pages/Usuarios/UsuariosCard";

const Usuarios = (): JSX.Element => {
  useEffect((): void => {
    alterarTitlePagina("Usuários");
  }, []);

  return <UsuariosCard />;
};

export default Usuarios;
