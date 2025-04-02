import { memo } from "react";
import { Button } from "@mui/material";
import { IDefaultButtonProps } from "./interface/IDefaultButtonProps";

const DefaultButton = <T,>({
  children,
  onClick,
  fullWidth = true,
  disabled = false,
}: IDefaultButtonProps<T>) => {
  return (
    <Button
      variant="contained"
      onClick={onClick}
      fullWidth={fullWidth}
      sx={{ backgroundColor: "#D32F2F" }}
      disabled={disabled}
    >
      {children}
    </Button>
  );
};

export default memo(DefaultButton) as typeof DefaultButton;
