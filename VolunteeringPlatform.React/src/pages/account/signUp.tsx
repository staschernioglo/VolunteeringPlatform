import { useForm } from 'react-hook-form';

export default function SignUp() {
  const { register, handleSubmit, formState: { errors } } = useForm();
  const onSubmit = () => console.log("");
  console.log(errors);
  
  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <input type="text" placeholder="Full Name" {...register("Full Name", {required: true, max: 100, maxLength: 100})} />
      <input type="text" placeholder="Username" {...register("Username", {required: true, max: 20, min: 5, maxLength: 20})} />
      <input type="password" placeholder="Password" {...register("Password", {required: true, max: 20, min: 8, maxLength: 20})} />
      <input type="password" placeholder="Confirm Password" {...register("Confirm Password", {required: true, max: 20, min: 8, maxLength: 20})} />
      <input type="text" placeholder="Email" {...register("Email", {required: true, pattern: /^\S+@\S+$/i})} />
      <input type="text" placeholder="Locality" {...register("Locality", {required: true, max: 30, min: 3, maxLength: 30})} />
      <input type="tel" placeholder="Phone number" {...register("Phone number", {min: 4, maxLength: 15})} />
      <textarea {...register("Information", {min: -1})} />
      <input type="url" placeholder="Image" {...register("Image", {})} />

      <input type="submit" />
    </form>
  );
}