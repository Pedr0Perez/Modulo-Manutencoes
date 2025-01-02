import { Navigate } from "react-router-dom";

const RedirecionarPaginaInicial = (): JSX.Element => {
  return <Navigate to="/home" />;
};

export default RedirecionarPaginaInicial;
