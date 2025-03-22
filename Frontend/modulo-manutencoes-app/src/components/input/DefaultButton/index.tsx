import { memo } from "react";
import { Button } from "@mui/material";
import { IDefaultButtonProps } from "./interface/IDefaultButtonProps";

const DefaultButton = ({
  children,
  onClick,
  fullWidth = true,
}: IDefaultButtonProps) => {
  return (
    <Button
      variant="contained"
      onClick={onClick}
      fullWidth={fullWidth}
      sx={{ backgroundColor: "#D32F2F" }}
    >
      {children}
    </Button>
  );
};

export default memo<IDefaultButtonProps>(DefaultButton);
