import { memo } from "react";
import { TextField } from "@mui/material";
import { DefaultTextFieldProps } from "./interface/DefaultTextFieldProps";
import { ThemeProvider, useTheme } from "@mui/material/styles";
import customTheme from "./function/customTheme";

const DefaultTextField = ({
  label,
  value,
  setValue,
  valueInObject = false,
  name = "",
  fullWidth = true,
  className = "",
  type = "",
}: DefaultTextFieldProps) => {
  const outerTheme = useTheme();

  return (
    <ThemeProvider theme={customTheme(outerTheme)}>
      <TextField
        label={label}
        value={value}
        onChange={(e) => {
          if (!valueInObject) {
            setValue(e.target.value);
            return;
          }

          setValue((prevState: any) => ({
            ...prevState,
            [name]: e.target.value,
          }));
        }}
        fullWidth={fullWidth}
        className={className}
        type={type}
        sx={{ borderColor: "red" }}
      />
    </ThemeProvider>
  );
};

export default memo<DefaultTextFieldProps>(DefaultTextField);
