import { useEffect } from "react";
import alterarTitleDom from "../../utils/generic/alterarTitleDom";

const Usuarios = (): React.JSX.Element => {
  useEffect(() => {
    alterarTitleDom("Usuários");
  }, []);

  return <></>;
};

export default Usuarios;
