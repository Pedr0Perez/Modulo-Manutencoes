export interface IDefaultCheckboxProps<T> {
  label: string;
  value: boolean;
  setValue: T;
  valueInObject?: boolean;
  name?: string;
  className?: string;
}
