export interface IDefaultButtonProps<T> {
  children?: T;
  onClick?: React.MouseEventHandler<HTMLButtonElement>;
  fullWidth?: boolean;
  disabled?: boolean;
}
