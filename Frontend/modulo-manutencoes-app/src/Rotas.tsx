import { Route, Routes, Router, BrowserRouter, unstable_HistoryRouter as HistoryRouter } from "react-router-dom";
import Login from "./pages/Login";
import Home from "./pages/Home";
import NotFound404 from "./error/NotFound404";
import PrivateRoute from "./routes/PrivateRoute";
import DefaultLayout from "./components/layout/DefaultLayout";
import LoginRoute from "./routes/LoginRoute";
import { createBrowserHistory } from "history";

const Rotas = (): React.JSX.Element => {
  const history = createBrowserHistory();

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
              <DefaultLayout />
            </PrivateRoute>
          }
        >
          <Route path="home" element={<Home />} />
        </Route>
        <Route path="*" element={<NotFound404 />} />
      </Routes>
    </HistoryRouter>
  );
};

export default Rotas;
