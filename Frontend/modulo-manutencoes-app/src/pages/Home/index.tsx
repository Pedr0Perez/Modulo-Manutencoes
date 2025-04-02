import DefaultCard from "../../components/layout/DefaultCard";
import HomeOutlinedIcon from "@mui/icons-material/HomeOutlined";

const Home = (): React.JSX.Element => {
  return (
    <DefaultCard
      icon={<HomeOutlinedIcon />}
      titulo="Página Inicial"
    ></DefaultCard>
  );
};

export default Home;
