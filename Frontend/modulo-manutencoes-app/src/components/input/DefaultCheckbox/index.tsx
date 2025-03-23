import { memo } from "react";
import { Checkbox, FormControlLabel } from "@mui/material";
import { IDefaultCheckboxProps } from "./interface/IDefaultCheckboxProps";

const DefaultCheckbox = ({
  label,
  value,
  setValue,
  valueInObject = false,
  name = "",
  className = "",
}: IDefaultCheckboxProps) => {
  return (
    <FormControlLabel
      control={
        <Checkbox
          sx={{
            "&.Mui-checked": {
              color: " #D32F2F",
            },
          }}
          onChange={(e) => {
            if (!valueInObject) {
              setValue(e.target.checked);
              return;
            }

            setValue((prevState: any) => ({
              ...prevState,
              [name]: e.target.checked,
            }));
          }}
          checked={value}
          className={className}
        />
      }
      label={label}
    />
  );
};

export default memo(DefaultCheckbox);
