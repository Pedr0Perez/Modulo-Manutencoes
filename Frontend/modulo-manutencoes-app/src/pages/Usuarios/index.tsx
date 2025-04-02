import { useEffect } from "react";
import alterarTitleDom from "../../utils/generic/alterarTitleDom";
import CardGerenciamentoUsuarios from "../../components/pages/GerenciamentoUsuarios/CardGerenciamentoUsuarios";

const Usuarios = (): React.JSX.Element => {
  useEffect(() => {
    alterarTitleDom("Gerenciamento de Usuários");
  }, []);

  return <CardGerenciamentoUsuarios />;
};

export default Usuarios;
