import ITitlePageProps from "../interfaces/ITitlePageProps";
import alterarTitlePagina from "../utils/generic/alterarTitlePagina";
import HomeCard from "../components/pages/Home/HomeCard";
import { useEffect } from "react";

const Home = ({ title }: ITitlePageProps): JSX.Element => {
  alterarTitlePagina(title!);

  useEffect(() => {}, []);

  return (
    <>
      <HomeCard />
    </>
  );
};

export default Home;
