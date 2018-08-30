import _ from 'lodash';
import DateUtils from 'utils/DateUtils';

import DutiesSource from '../sources/DutiesSource';
import RequirementsSource from '../sources/RequirementsSource';
import { Departures, EmploymentTypes, BranchOffices, VacancyStatuses } from '../constants/EnumsConstants';

export const defineSalaryString = (from, to) => {
  if (!from && !to) return 'Зарплата не указана';
  if (!from) return `до ${to} руб.`;
  if (!to) return `от ${from} руб.`;
  if (from === to) return `${from} руб.`;
  return `${from} - ${to} руб.`;
};

export const FormatStatusToServer = ({ status, ...rest }) => ({
  ...rest,
  status: _.findIndex(VacancyStatuses, { name: status })
});

export const FormatStatusToClient = ({ status, ...rest }) => ({
  ...rest,
  status: _.get(VacancyStatuses[status], 'name')
});

export const FormatVacancyToClient = ({
  departureName,
  employmentType,
  branchOfficeCity,
  status,
  requirements,
  creationDate,
  ...rest
}) => {
  const reqs = _.partition(requirements, 'isAdditional');

  return _.omitBy({
    ...rest,
    departureName: _.get(Departures[departureName], 'name'),
    employmentType: _.get(EmploymentTypes[employmentType], 'name'),
    status: _.get(VacancyStatuses[status], 'name'),
    branchOfficeCity: _.get(BranchOffices[branchOfficeCity], 'name'),
    requirements: reqs[0],
    additionalRequirements: reqs[1],
    creationDate: DateUtils.moment(creationDate)
  }, _.isEmpty);
};

export const FormatVacancyToServer = ({
  departureName,
  employmentType,
  branchOfficeCity,
  status,
  requirements,
  additionalRequirements,
  ...rest
}) => ({
  ...rest,
  departureName: _.findIndex(Departures, { name: departureName }),
  employmentType: _.findIndex(EmploymentTypes, { name: employmentType }),
  status: _.findIndex(VacancyStatuses, { name: status }),
  branchOfficeCity: _.findIndex(BranchOffices, { name: branchOfficeCity }),
  requirements: _.concat(
    requirements || [],
    _.map(additionalRequirements, req => ({ ...req, isAdditional: true }))
  )
});

export const LoadDuties = search => DutiesSource
  .getDuties({ search })
  .then(({ response }) => response.map(({ id, name }) => ({ value: id, label: name })));

export const CreateDuty = name => DutiesSource.createDuty({ name });

export const LoadRequirements = search => RequirementsSource
  .getRequirements({ search })
  .then(({ response }) => response.map(({ id, name }) => ({ value: id, label: name })));

export const CreateRequirement = name => RequirementsSource.createRequirement({ name });
