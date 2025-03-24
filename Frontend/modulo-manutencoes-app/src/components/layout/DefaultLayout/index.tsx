import Header from "../Header";
import ContentPage from "../ContentPage";
import Footer from "../Footer";
import { Outlet } from "react-router-dom";
import verificarSessaoAtiva from "../../../middlewares/verificarSessaoAtiva";

const DefaultLayout = () => {
  return (
    <>
      <Header />
      <ContentPage>
        <Outlet />
      </ContentPage>
      <Footer />
    </>
  );
};

export default DefaultLayout;
