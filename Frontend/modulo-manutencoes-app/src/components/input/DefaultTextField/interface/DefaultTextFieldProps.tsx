export interface DefaultTextFieldProps<T> {
  label: string;
  value: string | null;
  setValue: React.Dispatch<React.SetStateAction<T>>;
  valueInObject?: boolean;
  name?: string;
  fullWidth?: boolean;
  className?: string;
  type?: string;
  error?: boolean;
  helperText?: string;
  disabled?: boolean;
}
