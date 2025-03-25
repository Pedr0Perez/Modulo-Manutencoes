import Header from "../Header";
import ContentPage from "../ContentPage";
import Sidebar from "../Sidebar";
import Footer from "../Footer";
import { Outlet } from "react-router-dom";

const DefaultLayout = () => {
  return (
    <>
      <Header />
      <ContentPage>
        <>
          <Sidebar />
          <Outlet />
        </>
      </ContentPage>
      <Footer />
    </>
  );
};

export default DefaultLayout;
