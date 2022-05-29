export const categories = ['Nature', 'Healthcare', 'Education', 'Older generation', 'Veterans', 'Ecology',
 'Children and youth', 'Animals', 'Sport', 'Other'];

export interface ProjectForCreateDto {
    name: string;
    category: string;
    description?: string;
    date?: Date;
    locality?: string;
    address?: string;
    requiredNumberOfvolunteers?: number;
    image?: File;
}

export interface ProjectListDto {
    id?: number;
    name?: string;
    category?: string;
    date?: Date;
    locality?: string;
    address?: string;
    requiredNumberOfvolunteers?: number;
    numberOfParticipatingVolunteers?: number;
    organization?: string;
    imageUrl?: string;
}
