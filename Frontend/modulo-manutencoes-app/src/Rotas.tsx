import { Route, Routes, BrowserRouter } from "react-router-dom";
import Login from "./pages/Login";
import NotFound404 from "./error/NotFound404";

const Rotas = (): React.JSX.Element => {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/login" element={<Login />} />
        <Route path="*" element={<NotFound404 />} />
      </Routes>
    </BrowserRouter>
  );
};

export default Rotas;
