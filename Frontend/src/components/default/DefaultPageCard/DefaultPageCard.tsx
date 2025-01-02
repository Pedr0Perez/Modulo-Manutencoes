import { memo } from "react";
import { Card } from "primereact/card";
import IDefaultPageCard from "./interface/IDefaultPageCard";
import "./style/DefaultPageCard.css";
import { Divider } from "primereact/divider";

const DefaultPageCard = ({
  title,
  children,
  className = "",
}: IDefaultPageCard): JSX.Element => {
  return (
    <div className="flex flex-column h-100">
      <Card
        title={title}
        className={`default-page-card h-100${
          className !== "" ? " " + className : ""
        }`}
      >
        <Divider className="mt-0" />
        {children}
      </Card>
    </div>
  );
};

export default memo(DefaultPageCard);
