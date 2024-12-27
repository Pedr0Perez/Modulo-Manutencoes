import { BrowserRouter } from "react-router-dom";
import { Route } from "react-router-dom";
import Home from "../pages/Home";
import { Routes } from "react-router-dom";

const Rotas = (): JSX.Element => {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="home" element={<Home />} />
      </Routes>
    </BrowserRouter>
  );
};

export default Rotas;
