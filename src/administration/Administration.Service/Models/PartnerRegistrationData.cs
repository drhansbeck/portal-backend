/********************************************************************************
 * Copyright (c) 2021, 2023 BMW Group AG
 * Copyright (c) 2021, 2023 Contributors to the Eclipse Foundation
 *
 * See the NOTICE file(s) distributed with this work for additional
 * information regarding copyright ownership.
 *
 * This program and the accompanying materials are made available under the
 * terms of the Apache License, Version 2.0 which is available at
 * https://www.apache.org/licenses/LICENSE-2.0.
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations
 * under the License.
 *
 * SPDX-License-Identifier: Apache-2.0
 ********************************************************************************/

using Org.Eclipse.TractusX.Portal.Backend.PortalBackend.PortalEntities.Enums;
using Org.Eclipse.TractusX.Portal.Backend.Registration.Common;
using System.Text.Json.Serialization;
using RegistrationData = Org.Eclipse.TractusX.Portal.Backend.Registration.Common.RegistrationData;

namespace Org.Eclipse.TractusX.Portal.Backend.Administration.Service.Models;

public record PartnerRegistrationData
(
    string ExternalId,
    string Name,
    [property: JsonPropertyName("bpn")] string? BusinessPartnerNumber,
    string City,
    string StreetName,
    string CountryAlpha2Code,
    string? Region,
    string? StreetNumber,
    string? ZipCode,
    IEnumerable<CompanyUniqueIdData> UniqueIds,
    IEnumerable<UserDetailData> UserDetails,
    IEnumerable<CompanyRoleId> CompanyRoles
) : Registration.Common.RegistrationData(Name, City, StreetName, CountryAlpha2Code, BusinessPartnerNumber, null, Region, null, StreetNumber, ZipCode, UniqueIds);

public record UserDetailData(
    Guid? IdentityProviderId,
    string ProviderId,
    string Username,
    string FirstName,
    string LastName,
    string Email
);

public record UserTransferData(
    string FirstName,
    string LastName,
    string Email,
    Guid IdentityProviderId,
    string ProviderId,
    string Username
);