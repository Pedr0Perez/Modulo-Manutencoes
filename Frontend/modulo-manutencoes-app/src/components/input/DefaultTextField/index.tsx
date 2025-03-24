import { memo } from "react";
import { TextField } from "@mui/material";
import { DefaultTextFieldProps } from "./interface/DefaultTextFieldProps";
import { ThemeProvider, useTheme } from "@mui/material/styles";
import customTheme from "./function/customTheme";

const DefaultTextField = <T,>({
  label,
  value,
  setValue,
  valueInObject = false,
  name = "",
  fullWidth = true,
  className = "",
  type = "",
  error = false,
  helperText = "",
  disabled = false,
}: DefaultTextFieldProps<T>) => {
  const outerTheme = useTheme();

  return (
    <ThemeProvider theme={customTheme(outerTheme)}>
      <TextField
        label={label}
        value={value}
        onChange={(e: React.ChangeEvent<HTMLInputElement>) => {
          const newValue = e.target.value as unknown as T;

          if (!valueInObject) {
            setValue(newValue);
            return;
          }

          setValue((prevState: any) => ({
            ...prevState,
            [name]: newValue,
          }));
        }}
        fullWidth={fullWidth}
        className={className}
        type={type}
        sx={{ borderColor: "red" }}
        error={error}
        helperText={helperText}
        disabled={disabled}
      />
    </ThemeProvider>
  );
};

export default memo(DefaultTextField) as typeof DefaultTextField;
