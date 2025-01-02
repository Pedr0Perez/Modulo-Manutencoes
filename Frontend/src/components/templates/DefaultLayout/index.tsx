import { memo } from "react";
import "./style/DefaultLayout.css";
import { Outlet } from "react-router-dom";
import Header from "../Header";
import Footer from "../Footer";
import MainContent from "../MainContent";
import Sidebar from "../Sidebar";

const DefaultLayout = (): JSX.Element => {
  return (
    <>
      <Header />
      <MainContent>
        <Sidebar />
        <Outlet />
      </MainContent>
      <Footer />
    </>
  );
};

export default memo(DefaultLayout);
