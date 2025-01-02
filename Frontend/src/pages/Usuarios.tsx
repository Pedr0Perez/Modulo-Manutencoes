import { useEffect } from "react";
import UsuariosCard from "../components/pages/Usuarios/UsuariosCard";
import alterarTitlePagina from "../utils/generic/alterarTitlePagina";

const Usuarios = (): JSX.Element => {
  useEffect((): void => {
    alterarTitlePagina("Usuários");
  }, []);

  return <UsuariosCard />;
};

export default Usuarios;
