interface IDefaultButtonProps {
  label: string;
  severity?: string;
  className?: string;
  fullWidth?: boolean;
  onClick?: React.MouseEventHandler<HTMLButtonElement>;
}

export default IDefaultButtonProps;
