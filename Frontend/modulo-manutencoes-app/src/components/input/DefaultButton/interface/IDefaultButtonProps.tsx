import { ReactNode } from "react";

export interface IDefaultButtonProps<T> {
  children: ReactNode;
  onClick?: React.MouseEventHandler<HTMLButtonElement>;
  fullWidth?: boolean;
  disabled?: boolean;
}
