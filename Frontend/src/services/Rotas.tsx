import { BrowserRouter } from "react-router-dom";
import { Route } from "react-router-dom";
import Home from "../pages/Home";
import { Routes } from "react-router-dom";
import RedirecionarToPaginaInicial from "../utils/generic/RedirecionarToPaginaInicial";
import Error404NotFoundPage from "../error/Error404NotFoundPage";
import DefaultLayout from "../components/templates/DefaultLayout";

const Rotas = (): JSX.Element => {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<DefaultLayout />}>
          <Route path="*" element={<Error404NotFoundPage />} />
          <Route path="/" element={<RedirecionarToPaginaInicial />} />
          <Route path="home" element={<Home title="Página Inicial" />} />
        </Route>
      </Routes>
    </BrowserRouter>
  );
};

export default Rotas;
