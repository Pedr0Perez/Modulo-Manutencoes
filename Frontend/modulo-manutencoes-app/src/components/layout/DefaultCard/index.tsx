import { memo } from "react";
import { IDefaultCardProps } from "./interface/IDefaultCardProps";
import "./style/DefaultCard.css";
import { JSX } from "@emotion/react/jsx-runtime";
import { useControleAberturaSidebar } from "../../../contexts/ControleAberturaSidebarContext";
import { SidebarAberturaEnum } from "../../../enums/SidebarAberturaEnum";

const DefaultCard = ({
  titulo,
  icon,
  descricao,
  children,
}: IDefaultCardProps): JSX.Element => {
  const { controleSidebar } = useControleAberturaSidebar();

  return (
    <div
      className={`default-card${
        controleSidebar === SidebarAberturaEnum.Exibir ? " sidebar-open" : ""
      }`}
    >
      <div className="default-card-header">
        <h2 className="m-0 title-container">
          <span className="icon-container">{icon}</span>
          <span className="title-text-container">{titulo}</span>
        </h2>
        <small>{descricao}</small>
      </div>
      <div className="default-card-body">{children}</div>
    </div>
  );
};

export default memo(DefaultCard);
