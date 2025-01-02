import { BrowserRouter } from "react-router-dom";
import { Route } from "react-router-dom";
import { Routes } from "react-router-dom";
import RedirecionarToPaginaInicial from "../utils/generic/RedirecionarToPaginaInicial";
import Error404NotFoundPage from "../error/Error404NotFoundPage";
import DefaultLayout from "../components/templates/DefaultLayout";
import Home from "../pages/Home";
import Usuarios from "../pages/Usuarios";

const Rotas = (): JSX.Element => {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<DefaultLayout />}>
          <Route path="*" element={<Error404NotFoundPage />} />
          <Route path="/" element={<RedirecionarToPaginaInicial />} />
          <Route path="home" element={<Home />} />
          <Route path="usuarios" element={<Usuarios />} />
        </Route>
      </Routes>
    </BrowserRouter>
  );
};

export default Rotas;
