import { memo } from "react";
import "./style/Footer.css";
import GetEnv from "../../../utils/generic/GetEnv";

const Footer = (): JSX.Element => {
  const sisNome: string = GetEnv("APP_NOME");
  const sisVersao: string = GetEnv("APP_VERSION");

  return (
    <footer className="default-footer">
      <span className="sis-footer-info-container">
        <b className="m-0">
          <span>{sisNome} </span>
          <span>{sisVersao}</span>
        </b>
        <b className="m-0">
          <span>© 2025 Pedro Perez</span>
        </b>
      </span>
    </footer>
  );
};

export default memo(Footer);
