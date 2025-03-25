import {
  Route,
  Routes,
  unstable_HistoryRouter as HistoryRouter,
} from "react-router-dom";
import Login from "./pages/Login";
import Home from "./pages/Home";
import NotFound404 from "./error/NotFound404";
import PrivateRoute from "./routes/PrivateRoute";
import DefaultLayout from "./components/layout/DefaultLayout";
import LoginRoute from "./routes/LoginRoute";
import history from "./libs/history/history";
import Usuarios from "./pages/Usuarios";
import DefaultPage from "./components/layout/DefaultPage";

const Rotas = () => {
  return (
    <HistoryRouter history={history}>
      <Routes>
        <Route
          path="/login"
          element={
            <LoginRoute>
              <Login />
            </LoginRoute>
          }
        />
        <Route
          path="/"
          element={
            <PrivateRoute>
              <DefaultPage />
            </PrivateRoute>
          }
        >
          <Route path="home" element={<Home />} />
          <Route path="usuarios" element={<Usuarios />} />
        </Route>
        <Route path="*" element={<NotFound404 />} />
      </Routes>
    </HistoryRouter>
  );
};

export default Rotas;
