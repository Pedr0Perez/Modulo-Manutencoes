import alterarTitlePagina from "../utils/generic/alterarTitlePagina";
import HomeCard from "../components/pages/Home/HomeCard";
import { useEffect } from "react";

const Home = (): JSX.Element => {
  useEffect((): void => {
    alterarTitlePagina("");
  }, []);

  return (
    <>
      <HomeCard />
    </>
  );
};

export default Home;
