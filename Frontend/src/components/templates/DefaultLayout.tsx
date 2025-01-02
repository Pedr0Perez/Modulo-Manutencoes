import { memo } from "react";
import { Outlet } from "react-router-dom";
import Header from "./Header";
import Footer from "./Footer";
import MainContent from "./MainContent";
import "./style/DefaultLayout.css";

const DefaultLayout = () => {
  return (
    <>
      <Header />
      <MainContent>
        <Outlet />
      </MainContent>
      <Footer />
    </>
  );
};

export default memo(DefaultLayout);
