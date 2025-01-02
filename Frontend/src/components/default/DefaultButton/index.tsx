import { memo } from "react";
import { Button } from "primereact/button";
import IDefaultButtonProps from "./interface/IDefaultButtonProps";

const DefaultButton = ({
  label,
  severity = "",
  className = "",
  fullWidth = true,
  onClick,
}: IDefaultButtonProps) => {
  return (
    <Button
      label={label}
      className={`${fullWidth ? "w-full " : ""}${
        severity !== "" ? severity : "default-btn "
      }${className !== "" ? " " + className : ""}`}
      onClick={onClick}
    />
  );
};

export default memo(DefaultButton);
