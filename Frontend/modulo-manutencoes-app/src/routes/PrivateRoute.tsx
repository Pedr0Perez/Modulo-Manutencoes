import { Navigate } from "react-router-dom";
import verificarSessaoAtiva from "../middlewares/verificarSessaoAtiva";
import { IRoute } from "./interfaces/IRoute";

const PrivateRoute = ({ children }: IRoute): React.JSX.Element => {
  if (verificarSessaoAtiva()) {
    return children;
  }

  return <Navigate to="/login" />;
};

export default PrivateRoute;
