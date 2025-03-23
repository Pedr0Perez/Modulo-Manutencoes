export interface DefaultTextFieldProps {
  label: string;
  value: string | null;
  setValue: any;
  valueInObject?: boolean;
  name?: string;
  fullWidth?: boolean;
  className?: string;
  type?: string;
  error?: boolean;
  helperText?: string;
  disabled?: boolean;
}
