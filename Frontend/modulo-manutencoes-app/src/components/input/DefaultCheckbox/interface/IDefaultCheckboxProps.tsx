export interface IDefaultCheckboxProps<T> {
  label: string;
  value: boolean;
  setValue: React.Dispatch<React.SetStateAction<boolean>>;
  valueInObject?: boolean;
  name?: string;
  className?: string;
}
