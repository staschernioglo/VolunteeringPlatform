
export default interface OrganizationRegisterDto {
    userName: string;
    email: string;
    password: string;
    confirmPassword: string;
    fullName: string;
    description?: string;
    locality?: string;
    address?: string;
    phoneNumber?: string;
    image?: string;
}
interface ProjectDto {
    name: string;
    category: string;
}

export type {ProjectDto}