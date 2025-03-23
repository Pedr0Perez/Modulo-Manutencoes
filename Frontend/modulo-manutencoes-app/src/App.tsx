import Rotas from "./Rotas";
import "./style/Main.css";
import "./style/Layout.css";
import { ToastContainer } from "react-toastify";

const App = (): React.JSX.Element => {
  return (
    <>
      <Rotas />
      <ToastContainer />
    </>
  );
};

export default App;
