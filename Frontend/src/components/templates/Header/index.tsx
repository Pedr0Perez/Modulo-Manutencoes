import { memo } from "react";
import "./style/Header.css";
import LogoSis from "../../../assets/logo-sis.png";
import { NavigateFunction, useNavigate } from "react-router-dom";
import "../style/VarTemplate.css";

const Header = (): JSX.Element => {
  const navigate: NavigateFunction = useNavigate();

  const anchorClick = (
    event: React.MouseEvent<HTMLAnchorElement, MouseEvent>
  ): void => {
    event.preventDefault();
    navigate("/home");
  };

  return (
    <header className="default-header">
      <span className="sis-logo-header-container">
        <a href="/home" onClick={anchorClick} className="sis-logo-header-link">
          <img
            src={LogoSis}
            className="sis-logo-header"
            alt="Logotipo do Módulo de Manutenções"
          />
        </a>
      </span>
    </header>
  );
};

export default memo(Header);
